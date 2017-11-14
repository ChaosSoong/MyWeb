export default {
	state: {
		isLogin:false
	},
	mutations: {
		login(state){
			state.isLogin = true
		},
		exit(state){
			state.isLogin = false
		}
	},
	actions:{
		login(context){
			context.commit('login')
		},
		exit(context){
			context.commit('exit')
		}
	}
}